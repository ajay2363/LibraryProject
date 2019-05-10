using LibraryData;
using LibraryProject.Models.Catalog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Controllers
{
    public class CatalogController : Controller
    {
        private ILibraryAsset _assets;
        public CatalogController(ILibraryAsset assets)
        {
            _assets = assets;
        }

        public IActionResult Index()
        {
            var assetModels = _assets.GetAll();

            var listingResult = assetModels
            .Select(result => new AssetIndexListingModel
            {
                Id = result.Id,
                ImageUrl = result.ImageUrl,
                AuthororDirector = _assets.getAuthororDirector(result.Id),
                DeweyCallNumber = _assets.GetDeweyIndex(result.Id),
                Title = result.Title,
                Type = _assets.GetType(result.Id)

            });

            var model = new AssetIndexModel()
            {
                Assets = listingResult
            };
            return View(model);
               
        }
        public IActionResult Detail (int id)
        {
            var asset = _assets.GetByID(id);

            var model = new AssetDetailModel
            {
                AssetId = id,
                Title = asset.Title,
                Year = asset.Year,
                Cost = asset.Cost,
                Status = asset.Status.Name,
                ImageUrl = asset.ImageUrl,
                AuthororDirector = _assets.getAuthororDirector(id),
                CurrentLocation = _assets.GetCurrentLocation(id).Name,
                DeweyCallNumber = _assets.GetDeweyIndex(id),
                ISBN = _assets.GetIsbn(id)

            };
            return View(model);
        }
    }
}
