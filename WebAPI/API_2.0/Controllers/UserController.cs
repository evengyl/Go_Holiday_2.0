using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using DAL.Services;
using ModelsDAL = DAL.Models;
using ModelsAPI = API_2.Models;
using API_2.Mappers;
using API_2.Utils.RSACryptography;
using System.Linq;

namespace API_2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserRepository _userRepository = new UserRepository();
        KeyGenerator _keyGenerator;
        Decrypting decrypting = new Decrypting();

        public UserController(KeyGenerator keyGenerator)
        {
            _keyGenerator = keyGenerator;
        }



        [HttpGet]
        [Route("Gets")]
        public List<ModelsAPI.User> Gets()
        {
            return _userRepository.GetAll().Select(x => x.DALToAPI()).ToList();
        }


        [HttpGet]
        [Route("Get/{id:int}")]
        public ModelsDAL.User Get(int id)
        {
            ModelsDAL.User OneUser = _userRepository.Get(id);
            return OneUser;
        }


        [HttpPost]
        [Route("Login")]
        public ModelsAPI.User Login(ModelsDAL.User user)
        {
            string PrivateKey = _keyGenerator.PrivateKey;
            user.Password = decrypting.Decrypt(user.Password, PrivateKey);


            ModelsAPI.User OneUser = _userRepository.Login(user).DALToAPI();
            return OneUser;
        }


        

        [HttpPost]
        [Route("VerifyEmail")]
        public int VerifyEmail(ModelsAPI.VerifyUser content)
        {
            int OneUserID = _userRepository.VerifyEmail(content.Email) ;
            return OneUserID;
        }


        [HttpPost]
        [Route("Register")]
        public void Register(ModelsDAL.User user)
        {

            string PrivateKey = _keyGenerator.PrivateKey;
            user.Password = decrypting.Decrypt(user.Password, PrivateKey);

            _userRepository.Create(user);
        }


        [HttpGet]
        [Route("GetPublicKey")]
        public string GetPublicKey()
        {
            _keyGenerator.GenerateKeys(RSAKeySize.Key1024);
            string publicKey = _keyGenerator.PublicKey;

            return publicKey;
        }





        [HttpPost]
        [Route("Post")]
        public void Post(ModelsDAL.User user)
        {
            _userRepository.Create(user);
        }




        [HttpPost]
        [Route("Update")]
        public IActionResult Update(ModelsAPI.UserInfos user)
        {
           _userRepository.Update(user.UserInfos_ApiToDAL());
            return Ok();
        }


        [HttpDelete]
        [Route("Delete/{id:int}")]
        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}

