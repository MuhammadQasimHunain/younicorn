using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;

namespace YounicornApp.Web.ApiModels
{
    public class UserItemDTO
    {
        #region Properties
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public string RedirectUrl { get; set; }

        #endregion

        public static UserItemDTO FromUserItem(User item)
        {
            return new UserItemDTO()
            {
                Id = item.Id,
                Firstname = item.Firstname,
                Lastname = item.Lastname,
                Username = item.Username,
                Phone = item.Phone,
                Email = item.Email,
                IsActive = item.IsActive,
                RoleId = item.RoleId
            };
        }
    }
}
