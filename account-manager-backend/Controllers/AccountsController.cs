using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using account_manager_backend.Data;
using account_manager_backend.Models;

namespace account_manager_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly account_manager_backendContext _context;

        public AccountsController(account_manager_backendContext context)
        {
            _context = context;
        }

        // GET: /GetAccounts
        [HttpGet("/GetAccounts")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            var accounts = await _context.Account.Where(a => a.IsObsolete != true).ToListAsync();

            return Ok(accounts);
        }

        // GET: /GetAccount?AccountId={ accountId }
        [HttpGet("/GetAccount")]
        public async Task<ActionResult<Account>> GetAccountByAccountId(int accountId)
        {
            var account = await _context.Account.FirstOrDefaultAsync(a => a.AccountId == accountId & a.IsObsolete != true);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        // PUT: /EditAccount?AccountId={ AccountId } + Account JSON Object
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/EditAccount")]
        public async Task<IActionResult> EditAccount(int accountId, Account account)
        {
            if (accountId != account.AccountId)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(accountId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(account);
        }

        // POST: /AddAccount + Account JSON Object
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/AddAccount")]
        public async Task<ActionResult<Account>> AddAccount(Account account)
        {
            _context.Account.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountByAccountId", new { accountId = account.AccountId }, account);
        }
        // ONLY FOR ADMIN USE!!
        // DELETE: /DeleteAccount?AccountId={ accountId }
        [HttpDelete("/DeleteAccount")]
        public async Task<IActionResult> DeleteAccount(int accountId)
        {
            var account = await _context.Account.FindAsync(accountId);
            if (account == null)
            {
                return NotFound();
            }

            _context.Account.Remove(account);
            await _context.SaveChangesAsync();

            return Ok();
        }
        // HELPER METHODS
        private bool AccountExists(int id)
        {
            return _context.Account.Any(e => e.AccountId == id);
        }
    }
}
