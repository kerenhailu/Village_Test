using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Village_Test.Models;

namespace Village_Test.Controllers.API
{
    public class ResidentController : ApiController
    {
        VillageDbContext DBContext = new VillageDbContext();
        // GET: api/Resident
        public IHttpActionResult Get()
        {
            try
            {
                List<Resident> residents = DBContext.Residents.ToList();
                return Ok(residents);
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
                Resident resident = await DBContext.Residents.FindAsync(id);
                return Ok(new { resident });
            }
            catch (SqlException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // POST: api/Resident
        public async Task<IHttpActionResult> Post([FromBody] Resident resident)
        {
            try
            {
                DBContext.Residents.Add(resident);
                await DBContext.SaveChangesAsync();
                return Ok("success to Add");
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
        public async Task<IHttpActionResult> Put(int id, [FromBody] Resident resident)
        {
            try
            {

                Resident residentToCange = await DBContext.Residents.FindAsync(id);
                residentToCange.FirstName = resident.FirstName;
                residentToCange.FatherName = resident.FatherName;
                residentToCange.IsBornInTheVillage = resident.IsBornInTheVillage;
                residentToCange.Birthday = resident.Birthday;
                residentToCange.Gender = resident.Gender;
                await DBContext.SaveChangesAsync();
                return(Ok("you Change the resident"));
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
                Resident residentToDelete = await DBContext.Residents.FindAsync(id);
                DBContext.Residents.Remove(residentToDelete);
                await DBContext.SaveChangesAsync();
                return Ok();
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
