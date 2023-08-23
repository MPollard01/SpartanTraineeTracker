using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Category;
using TraineeTracker.Application.Features.Categories.Requests.Queries;

namespace TraineeTracker.Application.Features.Categories.Handlers.Queries
{
    public class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, List<CategoryDetailDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryListRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDetailDto>> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetCategoriesWithSubCategories();
            return _mapper.Map<List<CategoryDetailDto>>(categories);
        }
    }
}
