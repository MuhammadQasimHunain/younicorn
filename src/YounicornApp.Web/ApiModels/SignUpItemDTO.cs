using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;

namespace YounicornApp.Web.ApiModels
{
    public class SignUpItemDTO
    {
        #region Properties

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int IspOfferId { get; set; }
        public IspOffer IspOffer { get; set; }
        
        #endregion

        public static SignUpItemDTO FromSignUpItem(SignUpDetails item)
        {
            return new SignUpItemDTO()
            {
                Id = item.Id,
                Firstname = item.Firstname,
                Lastname = item.Lastname,
                Username = item.Username,
                Phone = item.Phone,
                Email = item.Email,
                IspOfferId = item.IspOfferId,
                IspOffer = item.IspOffer
            };
        }

        public static SignUpDetails ToSignUpDetailsItem(SignUpItemDTO item)
        {
            return new SignUpDetails()
            {
                Id = item.Id,
                Firstname = item.Firstname,
                Lastname = item.Lastname,
                Username = item.Username,
                Phone = item.Phone,
                Email = item.Email,
                IspOfferId = item.IspOfferId,
            };
        }
    }
}
