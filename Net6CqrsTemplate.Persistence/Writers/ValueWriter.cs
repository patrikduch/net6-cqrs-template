﻿using AutoMapper;
using Net6CqrsTemplate.Application.Contracts.Persistence.Uow;
using Net6CqrsTemplate.Application.Contracts.Persistence.Writters;
using Net6CqrsTemplate.Application.Dtos.Value.Requests;
using Net6CqrsTemplate.Domain.Entities;

namespace Net6CqrsTemplate.Persistence.Writers
{
    public class ValueWriter : IValueWriter
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ValueWriter(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _uow =  uow ?? throw new ArgumentNullException(nameof(uow));
        }

        public async Task<ValueEntity?> CreateNewValueItem(InsertValueItemRequestDto newValueItem)
        {
            var valueEntity = _mapper.Map<ValueEntity>(newValueItem);
            valueEntity = await _uow.ValueRepository.Add(valueEntity);

            var resultSign = await _uow.Complete();

            if (resultSign is 0)
            {
                throw new Exception("New data cannot be saved.");
            }

            return valueEntity;
        }

        public async Task<ValueEntity> RemoveValueItem(int valueItemId)
        {
            var valueEntity = await _uow.ValueRepository.Get(valueItemId);

            if (valueEntity is null)
            {
                throw new Exception("Cannot find entity with id: " + valueItemId);
            }

            _uow.ValueRepository.Remove(valueEntity);
            await _uow.Complete();

            return valueEntity;
        }

        public async Task<ValueEntity?> UpdateValueItem(UpdateValueItemRequestDto newValueItem)
        {
            var valueEntity = await _uow.ValueRepository.Get(newValueItem.Id);

            if (valueEntity is null) throw new Exception("Entity with this id doesnt exists.");

            _mapper.Map(newValueItem, valueEntity);

            await _uow.Complete();

            return valueEntity;
        }
    }
}
