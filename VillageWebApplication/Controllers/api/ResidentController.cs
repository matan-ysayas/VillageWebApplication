using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VillageWebApplication.Models;

namespace VillageWebApplication.Controllers.api
{
    public class ResidentController : ApiController
    {
        VillageContext villageDB=new VillageContext();
        // GET: api/Resident
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(villageDB.Residents.ToList());
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Resident/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                return Ok(await villageDB.Residents.FindAsync(id));
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Resident
        public async Task<IHttpActionResult> Post([FromBody]Resident value)
        {
            try
            {
                villageDB.Residents.Add(value);
                await villageDB.SaveChangesAsync();
                return Ok("item was ADD");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Resident/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]Resident value)
        {
            try
            {
                Resident resident = await villageDB.Residents.FindAsync(id);
                resident.FirstName= value.FirstName;
                resident.FatherName = value.FatherName;
                resident.Gender = value.Gender;
                resident.BornInVillage = value.BornInVillage;
                resident.YearOfBirth = value.YearOfBirth;
                await villageDB.SaveChangesAsync();
                return Ok("itam was update");

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Resident/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                villageDB.Residents.Remove(await villageDB.Residents.FindAsync(id));
                await villageDB.SaveChangesAsync();

                return Ok("item was deleted");

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
