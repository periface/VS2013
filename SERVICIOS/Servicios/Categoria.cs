﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Repositorios;
using SERVICIOS.Models;
using AutoMapper;
namespace SERVICIOS.Servicios
{
    public class Categoria : ICategoria
    {
        IRepositorioGenerico<catCategorias> _Categorias;
        public Categoria(IRepositorioGenerico<catCategorias> _Categorias)
        {
            this._Categorias = _Categorias;
        }
        public Categoria() : this(new RepositorioGenerico<catCategorias,dbCITEmpleadoEntities>())
        {
            Mapper.CreateMap<catCategorias, MCategoria>();
            Mapper.CreateMap<MCategoria, catCategorias>();
        }
        public void GuardarCategoria(catCategorias model)
        {
            throw new NotImplementedException();
        }

        public void EditarCategoria(catCategorias model)
        {
            throw new NotImplementedException();
        }

        public void EliminarCategoria(catCategorias model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MCategoria> CargarCategorias()
        {
            List<MCategoria> categorias = new List<MCategoria>();
            var listaCategorias = _Categorias.CargaRegistro();
            foreach (var item in listaCategorias)
            {
                var cat = Mapper.Map<catCategorias, MCategoria>(item);
                categorias.Add(cat);
            }
            return categorias;
        }

        public IEnumerable<MCategoria> CargarCategorias(System.Linq.Expressions.Expression<Func<DAL.catCategorias, bool>> expresion)
        {
            List<MCategoria> categorias = new List<MCategoria>();
            var listaCategorias = _Categorias.CargaRegistro(expresion);
            foreach (var item in listaCategorias)
            {
                var cat = Mapper.Map<catCategorias, MCategoria>(item);
                categorias.Add(cat);
            }
            return categorias;
        }
    }
}
