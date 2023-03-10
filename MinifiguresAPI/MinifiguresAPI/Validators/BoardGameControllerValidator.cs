using FluentValidation;
using MinifiguresAPI.Models.ModelsDto;

namespace MinifiguresAPI.Validators

{
    public class BoardGameCreateValidator : AbstractValidator<BoardGameCreateDto>
    {
        public BoardGameCreateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is Empty")
                .Length(0, 100).WithMessage("Allowable number of characters 0-100")
                .NotNull();
            RuleFor(x => x.Authors)
                .NotEmpty().WithMessage("Authors is Empty")
                .Length(0, 150).WithMessage("Allowable number of characters 0-150")
                .NotNull();
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is Empty")
                .Length(0, 2000).WithMessage("Allowable number of characters 0-2000")
                .NotNull();
            RuleFor(x => x.AvgPlaytime)
                .NotEmpty().WithMessage("Average playtime is Empty")
                .Length(0, 20).WithMessage("Allowable number of characters 0-20")
                .NotNull();
            RuleFor(x => x.PhysicalMinis)
                .NotEmpty().WithMessage("Number of minis is Empty")
                .Length(0, 100).WithMessage("Allowable number range 0-100")
                .NotNull();
        }
    }
    public class BoardGameUpdateValidator : AbstractValidator<BoardGameUpdateDto>
    {
        public BoardGameUpdateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is Empty")
                .Length(0, 100).WithMessage("Allowable number of characters 0-100")
                .NotNull();
            RuleFor(x => x.Authors)
                .NotEmpty().WithMessage("Authors is Empty")
                .Length(0, 150).WithMessage("Allowable number of characters 0-150")
                .NotNull();
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is Empty")
                .Length(0, 2000).WithMessage("Allowable number of characters 0-2000")
                .NotNull();
            RuleFor(x => x.AvgPlaytime)
                .NotEmpty().WithMessage("Average playtime is Empty")
                .Length(0, 20).WithMessage("Allowable number of characters 0-20")
                .NotNull();
            RuleFor(x => x.PhysicalMinis)
                .NotEmpty().WithMessage("Number of minis is Empty")
                .Length(0, 100).WithMessage("Allowable number range 0-100")
                .NotNull();
        }
    }
}
