using FluentValidation;

namespace Clipr.Application.Features.Commands.UploadVideo;

public class UploadVideoCommandValidator : AbstractValidator<UploadVideoCommand>
{
    public UploadVideoCommandValidator()
    {
        RuleFor(p => p.VideoName)
            .NotEmpty().WithMessage("Video name is required")   
            .MaximumLength(100).WithMessage("Video name must not exceed 100 characters");

        RuleFor(p => p.VideoUrl)
            .NotEmpty().WithMessage("Video URL is required")
            .MaximumLength(2000).WithMessage("Video URL must not exceed 2000 characters");

        RuleFor(p => p.VideoThumbnailUrl)
            .NotEmpty().WithMessage("Video thumbnail URL is required")
            .MaximumLength(2000).WithMessage("Video thumbnail URL must not exceed 2000 characters");
    }
}
