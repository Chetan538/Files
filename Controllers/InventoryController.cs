using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application.Models;
namespace Application.Controllers
{
    public class InventoryController : ApiController
    {
        ProductEntities DC = new ProductEntities();
        public IHttpActionResult Getstuff()
        {

            var results = DC.stuffs.ToList();
            return Ok(results);


        }
        [HttpPost]
        public IHttpActionResult stuffinsert(stuff stuffInsert)
        {
            DC.stuffs.Add(stuffInsert);
            DC.SaveChanges();

            return Ok();

        }

        public IHttpActionResult Getitemid(int id)
        {
            Stuffclass stuffdetails = null;
            stuffdetails = DC.stuffs.Where(x => x.itemid == id).Select(x => new Stuffclass()
            {
                itemid = x.itemid,
                name = x.name,
                descriptions = x.descriptions,
                price = x.price,



            }).FirstOrDefault<Stuffclass>();
            if (stuffdetails == null)
            {
                return NotFound();
            }
            return Ok(stuffdetails);


        }

        public IHttpActionResult Put(stuff st)
        {
            var updatestuff = DC.stuffs.Where(x => x.itemid == st.itemid).FirstOrDefault<stuff>();
            if (updatestuff != null)
            {
                updatestuff.itemid = st.itemid;
                updatestuff.name = st.name;
                updatestuff.descriptions = st.descriptions;
                updatestuff.price = st.price;
                DC.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var stuffdel = DC.stuffs.Where(x => x.itemid == id).FirstOrDefault();
            DC.Entry(stuffdel).State = System.Data.Entity.EntityState.Deleted;
            DC.SaveChanges();
            return Ok();

        }


    }
}
