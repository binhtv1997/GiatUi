using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiatDo.Model;
using GiatDo.Service.Service;
using GIatDo.ViewModel;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GIatDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly IAccountService _accountService;
        public StoreController(IStoreService storeService, IAccountService accountService)
        {
            _storeService = storeService;
            _accountService = accountService;
        }
        [HttpPost]
        public ActionResult CreateStore([FromBody]StoreCM model)
        {
            try
            {
                var checkAccount = _accountService.GetAccount(model.AccountId.Value);
                if (checkAccount == null)
                    return NotFound("Not Found");
                var result = _storeService.GetStores(s => s.Phone == model.Phone);
                if (result.Count() > 0)
                {
                    return BadRequest("Phone has been exsit");
                }
                Store newStore = model.Adapt<Store>();
                _storeService.CreateStore(newStore);
                _storeService.Save();
                return Ok(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetById")]
        public ActionResult GetStoreById(Guid Id)
        {
            return Ok(_storeService.GetStore(Id).Adapt<StoreVM>());
        }
        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            return Ok(_storeService.GetStores().Adapt<List<StoreVM>>());
        }
        [HttpPut("UpdateStore")]
        public ActionResult Update([FromBody]StoreUM model)
        {
            try
            {
                var result = _storeService.GetStores(s => s.Phone == model.Phone);
                if (result.Count() > 0)
                {
                    return BadRequest("Phone has been exsit");
                }
                _storeService.UpdateStore(model.Adapt<Store>());
                _storeService.Save();
                return Ok(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("Delete")]
        public ActionResult Delete(Guid Id)
        {
            try
            {
                return Ok(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetAccountId")]
        public ActionResult GetStoreByUserId(Guid Id)
        {

            return Ok(_storeService.GetStores().Where(s => s.AccountId == Id).ToList()[0].Adapt<StoreVM>());
        }
        [HttpGet("GetByUserID")]
        public ActionResult GetCustomerByAccountId(string Id)
        {
            var AccountId = _accountService.GetAccounts(a => a.User_Id.Equals(Id)).ToList();
            var result = _storeService.GetStores(c => c.AccountId == AccountId[0].Id).ToList();
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result[0].Adapt<StoreVM>());
        }
    }
}