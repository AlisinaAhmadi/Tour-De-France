using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Models;

namespace Tour_De_France.Service
{
    public class VIPService
    {
        private List<VIP> VIPs;
        public DbGenericService<VIP> DbService { get; set; }

        public VIPService(DbGenericService<VIP> dbService)
        {
            DbService = dbService;
            VIPs = dbService.GetObjectsAsync().Result.ToList();
        }

        public async Task AddVIP(VIP Vip)
        {
            VIPs.Add(Vip);
            await DbService.AddObjectAsync(Vip);
        }

        public IEnumerable<VIP> GetVIPs()
        {
            return VIPs;
        }

        public VIP GetVIP(int id)
        {
            foreach (VIP vip in VIPs)
            {
                if (vip.VIPId == id) return vip;
            }
            return null;
        }

        public async Task DeleteVIP(int VipId)
        {
            VIP vipToBeDeleted = VIPs.Find(vip => vip.VIPId == VipId);
            
            if (vipToBeDeleted !=null)
            {
                VIPs.Remove(vipToBeDeleted);
                await DbService.DeleteObjectAsync(vipToBeDeleted);
            }
        }

        public async Task UpdateVIP(VIP vip)
        {
            if (vip != null)
            {
                foreach (var v in VIPs)
                {
                    if (v.VIPId == vip.VIPId)
                    {
                        v.Titel = vip.Titel;
                        v.Description = vip.Description;
                        v.Price = vip.Price;
                    }
                }
                await DbService.UpdateObjectAsync(vip);
            }
        }

    }
}
