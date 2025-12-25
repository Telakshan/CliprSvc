using FluentValidation;

namespace Clipr.Modules.Upload.Application.Features.Commands.UploadVideo;

public class UploadVideoCommandValidator : AbstractValidator<UploadVideoCommand>
{
    public UploadVideoCommandValidator()
    {
        RuleFor(p => p.VideoFile)
            .NotEmpty().WithMessage("Video file to upload cannot be empty!");
    }
}
