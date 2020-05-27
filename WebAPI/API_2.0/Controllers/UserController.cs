using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using DAL.Services;
using ModelsDAL = DAL.Models.Users;
using ModelsAPI = API_2.Models.Users;
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


        public IActionResult Index()
        {
            return Ok();
        }


        [HttpGet]
        [Route("Gets")]
        public IActionResult Gets()
        {
            List<ModelsAPI.User> users = _userRepository.GetAll().Select(user => user.DALToAPI()).ToList();

            if (users != null)
                return Ok(users);
            else
                return NotFound();
        }


        [HttpGet]
        [Route("Get/{id:int}")]
        public IActionResult Get(int id)
        {
            ModelsAPI.User User = _userRepository.Get(id).DALToAPI();

            if (User != null)
                return Ok(User);
            else
                return NotFound();
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(ModelsDAL.UserALL user)
        {
            string PrivateKey = _keyGenerator.PrivateKey;
            user.Password = decrypting.Decrypt(user.Password, PrivateKey);


            ModelsAPI.User OneUser = _userRepository.Login(user).DALToAPI();
            if (OneUser != null)
                return Ok(OneUser);
            else
                return NotFound();
        }


        

        [HttpGet]
        [Route("VerifyEmail")]
        public IActionResult VerifyEmail(ModelsAPI.VerifyUser content)
        {
            int OneUserID = _userRepository.VerifyEmail(content.Email);

            if (OneUserID == 0)
                return NotFound();
            else
                return Ok(OneUserID);
        }


        [HttpPost]
        [Route("Register")]
        public IActionResult Register(ModelsDAL.UserALL user)
        {

            string PrivateKey = _keyGenerator.PrivateKey;
            user.Password = decrypting.Decrypt(user.Password, PrivateKey);

            _userRepository.Create(user);
            return Ok();
        }


        [HttpGet]
        [Route("GetPublicKey")]
        public IActionResult GetPublicKey()
        {
            _keyGenerator.GenerateKeys(RSAKeySize.Key1024);
            string publicKey = _keyGenerator.PublicKey;

            if(publicKey != null)
                return Ok(publicKey);
            else
                return NotFound();
        }





        [HttpPost]
        [Route("Post")]
        public IActionResult Post(ModelsDAL.UserALL user)
        {
            _userRepository.Create(user);
            return Ok();
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
        public IActionResult Delete(int id)
        {
            _userRepository.Delete(id);
            return Ok();
        }
    }
}

