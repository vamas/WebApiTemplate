using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bayer.MyBayer.WebApi.BusinessLogic.Model
{
    public interface BusinessAction<TIn, TOut> 
        where TIn: BusinessLogicEntity
        where TOut: BusinessLogicEntity
    {
        IImmutableList<ValidationResult> Errors { get; }
        bool HasErrors { get; }
        Task<TOut> Action(TIn dto);
    }
}