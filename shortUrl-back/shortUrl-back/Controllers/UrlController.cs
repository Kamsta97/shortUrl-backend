using Microsoft.AspNetCore.Mvc;
using shortUrl_back.DataContext;

namespace shortUrl_back.Controllers;

[ApiController]
[Route("[controller]")]
public class UrlController : ControllerBase
{
    private readonly UrlDbContext _dbContext;
    public UrlController(UrlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Url>>> GetUrls()
    {
        return await _dbContext.Url.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Url>> GetUrl(int id)
    {
        var url = await _dbContext.Url.FindAsync(id);

        if (url == null)
        {
            return NotFound();
        }

        return url;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUrl(int id, Url urlObject)
    {
        if (id != urlObject.UrlID)
        {
            return BadRequest();
        }

        var url = await _dbContext.Url.FindAsync(id);

        if (url == null)
        {
            return NotFound();
        }

        url.LongUrl = urlObject.LongUrl;
        url.ShortUrl = urlObject.ShortUrl;
        url.EntryCount = urlObject.EntryCount;
        url.CreateDate = urlObject.CreateDate;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!UrlExists(id))
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Url>> CreateUrl(Url urlObject)
    {

        _dbContext.Url.Add(urlObject);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetUrl),
            new { id = urlObject.UrlID },
            urlObject);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUrl(int id)
    {
        var todoItem = await _dbContext.Url.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        _dbContext.Url.Remove(todoItem);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    private bool UrlExists(long id)
    {
        return _dbContext.Url.Any(e => e.UrlID == id);
    }
}

