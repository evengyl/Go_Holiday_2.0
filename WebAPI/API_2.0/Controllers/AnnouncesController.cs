using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ModelsDAL = DAL.Models.Announces;
using ModelsAPI = API_2.Models.Announces;
using DAL.Services.AnnouncesRepo;
using API_2._0.Mappers;
using API_2.Models.Announces;

namespace API_2._0.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnnouncesController : ControllerBase
    {
        GetRepository _announcesRepositoryGET = new GetRepository();
        CreateRepository _announcesRepositoryCREATE = new CreateRepository();
        UpdateRepository _announcesRepositoryUPDATE = new UpdateRepository();
        public AnnouncesController()
        {

        }


        public IActionResult Index()
        {
            return Ok();
        }


        [HttpGet]
        [Route("Get/{AnnID:int}")]
        public IActionResult Get(int AnnID)
        {
            ModelsAPI.Announces announce = _announcesRepositoryGET.Get(AnnID).DALToAPI();

            if (announce != null)
                return Ok(announce);
            else
                return NotFound();
        }



        [HttpPost]
        [Route("Post")]
        public IActionResult Post(ModelsAPI.Announces Annonce)
        {
            int NewAnnId = _announcesRepositoryCREATE.Create(Annonce.APIToDAL());

            if(NewAnnId != 0)
            {
                _announcesRepositoryCREATE.PostSport(Annonce.ListSport.Select(x => x.APIToDALSport()).ToList(), NewAnnId);
                _announcesRepositoryCREATE.PostActivity(Annonce.ListActivity.Select(x => x.APIToDALActivity()).ToList(), NewAnnId);
                _announcesRepositoryCREATE.PostCommoditer(Annonce.ListCommoditer.Select(x => x.APIToDALCommoditer()).ToList(), NewAnnId);
                _announcesRepositoryCREATE.PostTypeHoliday(Annonce.ListTypeHoliday.Select(x => x.APIToDALTypeHoliday()).ToList(), NewAnnId);
                _announcesRepositoryCREATE.PostHabitat(Annonce.TypeHabitat.APIToDALTypeHabitat(), NewAnnId);
                return Ok();
            }
            else
            {
                return NotFound(NewAnnId);
            }
        }



        [HttpGet]
        [Route("Update")]
        public IActionResult Update(/*ModelsAPI.Announces Announce*/)
        {
            ModelsAPI.FakeModelAnnouncesTest fakeModelAnnouncesTest = new ModelsAPI.FakeModelAnnouncesTest();

            _announcesRepositoryUPDATE.Update(fakeModelAnnouncesTest.announce.APIToDAL());


            _announcesRepositoryUPDATE.UpdateSport(fakeModelAnnouncesTest.announce.ListSport.Select(x => x.APIToDALSport()).ToList(), fakeModelAnnouncesTest.announce.AnnID);
            _announcesRepositoryUPDATE.UpdateActivity(fakeModelAnnouncesTest.announce.ListActivity.Select(x => x.APIToDALActivity()).ToList(), fakeModelAnnouncesTest.announce.AnnID);
            _announcesRepositoryUPDATE.UpdateCommoditer(fakeModelAnnouncesTest.announce.ListCommoditer.Select(x => x.APIToDALCommoditer()).ToList(), fakeModelAnnouncesTest.announce.AnnID);
            _announcesRepositoryUPDATE.UpdateTypeHoliday(fakeModelAnnouncesTest.announce.ListTypeHoliday.Select(x => x.APIToDALTypeHoliday()).ToList(), fakeModelAnnouncesTest.announce.AnnID);
            _announcesRepositoryUPDATE.UpdateHabitat(fakeModelAnnouncesTest.announce.TypeHabitat.APIToDALTypeHabitat(), fakeModelAnnouncesTest.announce.AnnID);

            return Ok();
        }



        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<ModelsAPI.Announces> announces = _announcesRepositoryGET.GetAll().Select(x => x.DALToAPI()).ToList();

            foreach(ModelsAPI.Announces announce in announces)
            {
                announce.ListSport = _announcesRepositoryGET.GetSport(announce.AnnID).Select(x => x.DALToAPISport()).ToList();
                announce.ListActivity = _announcesRepositoryGET.GetActivity(announce.AnnID).Select(x => x.DALToAPIActivity()).ToList();
                announce.TypeHabitat = _announcesRepositoryGET.GetTypeHabitat(announce.AnnID).DALToAPITypeHabitat();
                announce.ListTypeHoliday = _announcesRepositoryGET.GetTypeHoliday(announce.AnnID).Select(x => x.DALToAPITypeHoliday()).ToList();
                announce.ListCommoditer = _announcesRepositoryGET.GetCommoditer(announce.AnnID).Select(x => x.DALToAPICommoditer()).ToList();
            }

            if (announces != null)
                return Ok(announces);
            else
                return NotFound();
        }


    }
}