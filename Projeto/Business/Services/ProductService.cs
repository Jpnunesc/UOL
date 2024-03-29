﻿using AutoMapper;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.IO;
using Business.IO.Product;
using Business.Validations;
using Domain.Entitys;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        public ProductService(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ReturnView> Save(ProductInput _product)
        {
            var validate = Validate(_product);
            if (!validate.Status)
            {
                return validate;
            }

            var productMap = _mapper.Map<ProductInput, ProductEntity>(_product);
            productMap.DateRegister = DateTime.Now;
            try
            {
                var objReturn = _mapper.Map<ProductEntity, ProductOutPut>(await _repository.Add(productMap));
                return objReturn.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public ReturnView Validate(ProductInput _product)
        {
            ReturnView retornView = new ReturnView();
            ProductValidation validator = new ProductValidation();
            var valid = validator.Validate(_product);
            if (!valid.IsValid)
            {
                retornView.Status = false;
                foreach (var item in valid.Errors)
                {
                    retornView.Message = string.IsNullOrEmpty(retornView.Message) ? item.ErrorMessage : retornView.Message + ", " + item.ErrorMessage;
                }
                return retornView;
            }
            retornView.Status = true;
            return retornView;
        }

        public async Task<ReturnView> Edit(ProductInput _product)
        {
            var validate = Validate(_product);
            if (!validate.Status)
            {
                return validate;
            }
            var productMap = _mapper.Map<ProductInput, ProductEntity>(_product);
            return new ReturnView() { Object = _mapper.Map<ProductEntity, ProductOutPut>(await _repository.Update(productMap)), Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> Delete(int id)
        {
            await _repository.Remove(id);
            return new ReturnView() { Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> Get(int id)
        {
            var filter = new ProductFilter() {Id = id };
            var listEntity = await _repository.GetFilter(filter);
            return new ReturnView() { Object = listEntity.Product.FirstOrDefault(), Message = "Operation performed successfully!", Status = true };
        }
        public async Task<ReturnView> GetMany(ProductFilter _filter)
        {
            var listEntity = await _repository.GetFilter(_filter);

            return new ReturnView() { Object = listEntity, Message = "Operation performed successfully!", Status = true };
        }
        public void Dispose()
        {
            _repository?.Dispose();
        }

    }
}
