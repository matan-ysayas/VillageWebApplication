using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VillageWebApplication.Models;

namespace VillageWebApplication.Controllers.api
{
    public class SeniorsController : ApiController
    {
        static string connectionString = "Data Source=.;Initial Catalog=EldersDB;Integrated Security=True;Pooling=False";
        EldersDBDataContext EldersDB=new EldersDBDataContext(connectionString);
        // GET: api/Seniors
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(EldersDB.Seniors.ToList());

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

        // GET: api/Seniors/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(EldersDB.Seniors.First((item) => item.Id == id));

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

        // POST: api/Seniors
        public IHttpActionResult Post([FromBody]Senior value)
        {
            try
            {
                EldersDB.Seniors.InsertOnSubmit(value);
                EldersDB.SubmitChanges();
                return Ok("item was add");

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

        // PUT: api/Seniors/5
        public IHttpActionResult Put(int id, [FromBody]Senior value)
        {
            try
            {
                Senior senior = EldersDB.Seniors.First((item) => item.Id == id);
                senior.Name = value.Name;
                senior.YearOfBirth = value.YearOfBirth;
                senior.Seniority=value.Seniority;
               EldersDB.SubmitChanges();
                return Ok("item was update");

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

        // DELETE: api/Seniors/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                EldersDB.Seniors.DeleteOnSubmit(EldersDB.Seniors.First((item) => item.Id == id));

                EldersDB.SubmitChanges();
                return Ok("Item deleted");
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
