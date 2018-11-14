using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebserviceTest.Classes;
using System.ComponentModel;
using Microsoft.AspNetCore.Hosting;

namespace WebserviceTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessesController : ControllerBase
    {
        //GET api/processes?name=foo
        //GET api/processes
        //Get all processes, optionally filter by name
        [HttpGet]
        public ActionResult<IEnumerable<ProcessSummary>> Get([FromQuery(Name = "name")] string name)
        {
            IEnumerable<ProcessSummary> processes;
            if (name != null)
                processes = Process.GetProcessesByName(name).Select(p => new ProcessSummary(p));
            else
                processes = Process.GetProcesses().Select(p => new ProcessSummary(p));

            return new OkObjectResult(processes);
        }

        //GET api/processes/PID
        //Get a process summary
        [HttpGet("{id}")]
        public ActionResult<ProcessSummary> Get(int id)
        {
            try
            {
                var process = new ProcessSummary(Process.GetProcessById(id));
                return process;
            }
            catch (ArgumentException)
            {
                return new NotFoundObjectResult(new { err_msg = "Process Id not found" });
            }
        }

        //DELETE api/processes/PID
        //Kill a process
        [HttpDelete("{id}")]
        public ActionResult Kill(int id)
        {
            ActionResult result;

            try
            {
                var process = Process.GetProcessById(id);
                process.Kill();
                result = new OkResult();
            }
            catch (ArgumentException)
            {
                result = new NotFoundObjectResult(new { err_msg = "Process Id not found" });
            }
            catch (Win32Exception)
            {
                result = new UnauthorizedResult();
            }

            return result;
        }
    }
}
