using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HMS.BAL.Interface;
using HMS.Models;

namespace HotelManagmentApi.Controllers
{
    public class HMSROOMController : ApiController
    {
        private readonly IHotelManager _hotelManager;

        public HMSROOMController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        public List<RoomModel> Get()
        {
            return _hotelManager.GetRooms();
        }

        public RoomModel Get(int id)
        {
            return _hotelManager.GetRoom(id);
        }

        public string Post([FromBody]RoomModel value)
        {
            return _hotelManager.CreateRoom(value);
        }

        public string Put( [FromBody]RoomModel value)
        {
            return _hotelManager.UpdateRoom(value);
        }

       }

}
