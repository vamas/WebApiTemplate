using Newtonsoft.Json;
using System.Collections.Generic;

namespace Web.Api.Dto
{
    public class PagedCollectionResponseDto<T>
    {
        public ICollection<T> Items { get; set; }

        public int Start { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<Link> Links { get; set; }

        public PagedCollectionResponseDto()
        {
            Items = new List<T>();
            Links = new List<Link>();
        }

        public string Serialized()
        {
            return JsonConvert.SerializeObject(new
            {
                Start = Start,
                Count = Count,
                TotalCount = TotalCount,
                TotalPages = TotalPages,
                Links = Links
            });
        }
    }
}