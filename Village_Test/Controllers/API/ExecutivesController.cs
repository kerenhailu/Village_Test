using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Village_Test.Models;

namespace Village_Test.Controllers.API
{
    public class ExecutivesController : ApiController
    {
        EldersDBDataContext dataContext = new EldersDBDataContext();
        // GET: api/Executives
        public IHttpActionResult Get()
        {
            try
            {
                List<Executive> ExecutivesList = dataContext.Executives.ToList();
                return Ok(new { ExecutivesList });
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

        // GET: api/Executives/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Executive executive = dataContext.Executives.First(item => item.Id == id);
                return Ok(new { executive });
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

        // POST: api/Executives
        public IHttpActionResult Post([FromBody] Executive executive)
        {
            try
            {
                dataContext.Executives.InsertOnSubmit(executive);
                dataContext.SubmitChanges();
                List<Executive> ExecutivesList = dataContext.Executives.ToList();
                return Ok(new { ExecutivesList });
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

        // PUT: api/Executives/5
        public IHttpActionResult Put(int id, [FromBody] Executive executive)
        {
            try
            {
                Executive executiveToChange = dataContext.Executives.First(item => item.Id == id);
                if (executiveToChange != null)
                {
                    executiveToChange.firstName = executive.firstName;
                    executiveToChange.birthday = executive.birthday;
                    executiveToChange.seniority = executive.seniority;
                }
                dataContext.SubmitChanges();
                return Ok("you change the executive");
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

        // DELETE: api/Executives/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Executive executiveToDelete = dataContext.Executives.First(item => item.Id == id);
                dataContext.Executives.DeleteOnSubmit(executiveToDelete);
                dataContext.SubmitChanges();
                return Ok("you Delete the executive");
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
