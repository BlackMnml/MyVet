using Microsoft.AspNetCore.Mvc.Rendering;
using MyVet.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _datacontext;

        public CombosHelper(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public IEnumerable<SelectListItem> GetComboPetTypes()
        {
            var list = _datacontext.PetTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                Value = $"{pt.Id}"
            }

                )
                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Pet Type]",
                Value = "0"

            });
            return list;
        }

    }
}
