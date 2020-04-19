using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Infrastructure;
using Web.Infrastructure.BusinessLogic.Model;
using Web.Infrastructure.Exceptions;
using Web.Services.Interface;

namespace Web.Api.Dto.Wrappers.ProductManagement
{
    public abstract class ProductManagementWrapper<T, D>
        where T: BusinessLogicEntity
        where D: DtoBase
    {
        protected IProductManagementService _productManagementService;
        protected ILogger _logger;
        protected HttpRequest _request;
        protected HttpResponse _response;
        protected IUrlHelper _url;

        public ProductManagementWrapper(IProductManagementService productManagementService,
            IUrlHelper url,
            HttpRequest request,
            HttpResponse response,
            ILogger logger)
        {
            _productManagementService = productManagementService;
            _url = url;
            _request = request;
            _response = response;
            _logger = logger;
        }

        internal delegate Task<T> SingleEntityDelegate<out Task>();

        internal IProductManagementService ProductManagementService => _productManagementService;

        internal string Controller => (_url == null) ? "Controller" : _url.ActionContext.RouteData.Values["Controller"].ToString();

        internal HttpRequest Request => _request;

        internal HttpResponse Response => _response;
        internal IUrlHelper UrlHelper => _url;

        public async Task<PagedCollectionResponseDto<D>> WrapCollection(Filter filter)
        {
            try
            {
                Func<Filter, Task<IEnumerable<T>>> filterData = async (filterModel) =>
                {
                    return await Get(filterModel);
                };

                //ValidateParameters(filter);

                //Get the data for the current page
                var result = new PagedCollectionResponseDto<D>();
                var items = await filterData(filter);

                //Add links
                foreach (var item in items)
                {
                    result.Items.Add(WrapItem(item));
                }

                //Get next page URL string
                Filter nextFilter = filter.Clone() as Filter;
                nextFilter.Page += 1;
                var nextUrl = (await filterData(nextFilter)).Any() ? null
                    : (UrlHelper != null) ? UrlHelper.Action("Get", null, nextFilter, Request.Scheme) : null;

                //Get previous page URL string
                Filter previousFilter = filter.Clone() as Filter;
                previousFilter.Page -= 1;
                var previousUrl = previousFilter.Page <= 0 ? null
                    : (UrlHelper != null) ? UrlHelper.Action("Get", null, previousFilter, Request.Scheme) : null;

                result.Start = ((filter.Page - 1) * filter.PageSize) + 1;
                result.TotalCount = GetTotalRecords();
                result.Count = result.Items.Count;
                result.TotalPages = result.TotalCount / ((filter.PageSize == 0) ? 1 : filter.PageSize);
                result.Links.Add(new Link(!String.IsNullOrWhiteSpace(nextUrl) ? new Uri(nextUrl).ToString() : "", "next"));
                result.Links.Add(new Link(!String.IsNullOrWhiteSpace(previousUrl) ? new Uri(previousUrl).ToString() : "", "previous"));

                if (Response != null)
                {
                    Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");
                    Response.Headers.Add("X-Pagination", result.Serialized());
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new InternalException("Error serializing collection", ex);
            }
        }

        internal abstract Task<IEnumerable<T>> Get(Filter filter);

        internal abstract D GetDtoObject(T item);

        internal abstract int GetTotalRecords();

        internal abstract List<Link> ItemLinks(D dtoItem);

        internal abstract string Title();

        internal abstract string ItemKeyToString(T item);

        public abstract Task<D> GetById(string id);

        public abstract Task<D> Update(T entity, string id);

        public abstract Task<D> Create(T entity);


        protected D WrapItem(T item)
        {
            var itemDto = GetDtoObject(item);
            try
            {
                ItemLinks(itemDto).Add(new Link((UrlHelper == null) ? "/" + Controller + "/" + ItemKeyToString(item) :
                    UrlHelper.Content("~/" + Controller + "/" + ItemKeyToString(item)),
                        "self",
                        "GET"));
                ItemLinks(itemDto).Add(new Link((UrlHelper == null) ? "" :
                    UrlHelper.Content("~/" + Controller),
                        "self",
                        "POST"));
                ItemLinks(itemDto).Add(new Link((UrlHelper == null) ? "/" + Controller + "/" + ItemKeyToString(item) :
                    UrlHelper.Content("~/" + Controller + "/" + ItemKeyToString(item)),
                        "self",
                        "DELETE"));
                ItemLinks(itemDto).Add(new Link((UrlHelper == null) ? "/" + Controller + "/" + ItemKeyToString(item) :
                    UrlHelper.Content("~/" + Controller + "/" + ItemKeyToString(item)),
                        "self",
                        "PUT"));
                ItemLinks(itemDto).Add(new Link((UrlHelper == null) ? "/" + Controller + "/" + ItemKeyToString(item) :
                    UrlHelper.Content("~/" + Controller + "/" + ItemKeyToString(item) + "/ForceUpdate"),
                        "self",
                        "PUT"));
            }
            catch (Exception ex)
            {
                throw new InternalException("Error serializing an item", ex);
            }
            return itemDto;
        }
    }
}
