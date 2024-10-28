using EventServices.Application.Features.SliderFeature.Commands.CreateSlider;
using EventServices.Application.Features.SliderFeature.Commands.DeleteSlider;
using EventServices.Application.Features.SliderFeature.Commands.UpdateSlider;
using EventServices.Application.Features.SliderFeature.Queries.GetAllSliders;
using EventServices.Application.Features.SliderFeature.Queries.GetSlider;
using EventServices.APi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EventServices.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SliderController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> FindAll()
    {
        var sliders = await Mediator.Send(new GetAllSlidersQuery());
        return Ok(sliders);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Find(Guid id)
    {
        var slider = await Mediator.Send(new GetSliderQuery(id));
        return Ok(slider);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateSliderCommand createSliderCommand)
    {
        var slider = await Mediator.Send(createSliderCommand);
        return CreatedAtAction(nameof(Find), new { id = slider.Id }, slider);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromForm] UpdateSliderCommand updateSliderCommand)
    {
        if (id != updateSliderCommand.Id)
        {
            return BadRequest("Id's don't match");
        }
        var slider = await Mediator.Send(updateSliderCommand);
        return Ok(slider);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (await Mediator.Send(new DeleteSliderCommand(id)))
        {
            return NoContent();
        }
        return BadRequest();
    }
    
    [HttpGet("GetAllNotDisabled")]
    public async Task<IActionResult> FindAllNotDisabled()
    {
        var sliders = await Mediator.Send(new GetAllSlidersQuery());
        return Ok(sliders);
    }
    
}