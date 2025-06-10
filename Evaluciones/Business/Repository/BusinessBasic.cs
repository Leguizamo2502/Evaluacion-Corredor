﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Interfaces.Base;
using Entity.Domain.Models.Base;
using Utilities.Exceptions;
using Utilities.Helpers.Business;

namespace Business.Repository
{
    public class BusinessBasic<TDto, TDtoGet, TEntity> : ABusinessBasic<TDto, TDtoGet, TEntity> where TEntity : BaseModel
    {
        protected readonly IMapper _mapper;
        protected readonly IData<TEntity> Data;

        /// <summary>
        /// Constructor que inicializa las dependencias principales
        /// </summary>
        /// <param name="data">Repositorio de datos para la entidad TEntity</param>
        /// <param name="mapper">Instancia de AutoMapper para transformaciones DTO-Entidad</param>
        public BusinessBasic(IData<TEntity> data, IMapper mapper)
        {
            Data = data; ;
            _mapper = mapper; ;
        }

        /// <summary>
        /// Obtiene todos los registros no eliminados (activos) de la entidad
        /// </summary>
        /// <returns>
        /// Colección de DTOs de consulta (TDtoGet) mapeados desde las entidades
        /// </returns>
        /// <exception cref="BusinessException">Error durante la operación de base de datos</exception>
        public override async Task<IEnumerable<TDtoGet>> GetAllAsync()
        {
            try
            {
                var entities = await Data.GetAllAsync();
                return _mapper.Map<IEnumerable<TDtoGet>>(entities);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al obtener todos los registros.", ex);
            }
        }

        /// <summary>
        /// Obtiene registros aplicando una estrategia de filtrado específica
        /// </summary>
        /// <param name="getAllType">Estrategia de filtrado a aplicar (enum GetAllType)</param>
        /// <returns>
        /// Colección filtrada de DTOs según la estrategia especificada
        /// </returns>
        /// <exception cref="BusinessException">Error durante la operación o estrategia no soportada</exception>
       

        /// <summary>
        /// Obtiene un registro específico por su identificador
        /// </summary>
        /// <param name="id">Identificador único del registro (mayor que 0)</param>
        /// <returns>
        /// DTO de consulta (TDtoGet) o null si no se encuentra el registro
        /// </returns>
        /// <exception cref="InvalidOperationException">Cuando el ID es inválido (≤ 0)</exception>
        /// <exception cref="BusinessException">Error durante la operación de base de datos</exception>
        public override async Task<TDtoGet?> GetByIdAsync(int id)
        {
            try
            {
                BusinessValidationHelper.ThrowIfZeroOrLess(id, "El ID debe ser mayor que cero.");

                var entity = await Data.GetByIdAsync(id);
                return entity == null ? default : _mapper.Map<TDtoGet>(entity);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error al obtener el registro con ID {id}.", ex);
            }
        }

        /// <summary>
        /// Crea un nuevo registro en el sistema
        /// </summary>
        /// <param name="dto">DTO con los datos para la creación</param>
        /// <returns>
        /// DTO de creación/actualización (TDto) con los datos del registro creado
        /// </returns>
        /// <exception cref="InvalidOperationException">Cuando el DTO es nulo o no pasa validaciones</exception>
        /// <exception cref="BusinessException">Error durante la operación de base de datos</exception>
        public override async Task<TDto> CreateAsync(TDto dto)
        {
            try
            {
                BusinessValidationHelper.ThrowIfNull(dto, "El DTO no puede ser nulo.");

                var entity = _mapper.Map<TEntity>(dto);
                entity.InitializeLogicalState(); // Inicializa estado lógico (is_deleted = false)

                var created = await Data.CreateAsync(entity);
                return _mapper.Map<TDto>(created);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al crear el registro.", ex);
            }
        }

        /// <summary>
        /// Actualiza un registro existente
        /// </summary>
        /// <param name="dto">DTO con los datos actualizados</param>
        /// <returns>
        /// True si la actualización fue exitosa, False si no se encontró el registro
        /// </returns>
        /// <exception cref="InvalidOperationException">Cuando el DTO es nulo o no pasa validaciones</exception>
        /// <exception cref="BusinessException">Error durante la operación de base de datos</exception>
        public override async Task<bool> UpdateAsync(TDto dto)
        {
            try
            {
                BusinessValidationHelper.ThrowIfNull(dto, "El DTO no puede ser nulo.");

                var entity = _mapper.Map<TEntity>(dto);
                entity.InitializeLogicalState(); // Mantiene el estado en un update normal
                return await Data.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error al actualizar el registro: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Elimina físicamente un registro de la base de datos
        /// </summary>
        /// <param name="id">Identificador único del registro (mayor que 0)</param>
        /// <returns>
        /// True si la eliminación fue exitosa, False si no se encontró el registro
        /// </returns>
        /// <exception cref="InvalidOperationException">Cuando el ID es inválido (≤ 0)</exception>
        /// <exception cref="BusinessException">Error durante la operación de base de datos</exception>
        public override async Task<bool> DeleteAsync(int id)
        {
            try
            {
                BusinessValidationHelper.ThrowIfZeroOrLess(id, "El ID debe ser mayor que cero.");


                return await Data.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error al eliminar el registro con ID {id}.", ex);
            }
        }

        public override async Task<bool> DeleteLogicAsync(int id)
        {
            try
            {
                BusinessValidationHelper.ThrowIfZeroOrLess(id, "El ID debe ser mayor que cero.");


                return await Data.DeleteLogicAsync(id);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error al eliminar logicamente el registro con ID {id}.", ex);
            }
        }
    }
}
