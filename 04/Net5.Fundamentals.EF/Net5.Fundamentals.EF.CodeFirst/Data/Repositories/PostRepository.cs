﻿using Net5.Fundamentals.EF.CodeFirst.Data.Contexts;
using Net5.Fundamentals.EF.CodeFirst.Data.Entities;
using Net5.Fundamentals.EF.CodeFirst.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Fundamentals.EF.CodeFirst.Data.Repositories
{
    public class PostRepository:GenericRepository<Post>,IPostRepository
    {
        public PostRepository(Net5FundamentalsEFDatabaseContext context):base(context)
        {

        }

        public List<Post> GetPostByUsuarioIdPropietario(int usuarioId)
        {
            return _context.Posts.Where(p => p.UsuarioIdPropietario == usuarioId).ToList();
        }
        public List<Post> GetPosts()
        {
            var queryPosts = from p in _context.Posts
                             join up in _context.Usuarios on p.UsuarioIdPropietario equals up.UsuarioId
                             select new Post
                             {
                                 PostId = p.PostId,
                                 Titulo = p.Titulo,
                                 Resumen = p.Resumen,
                                 Contenido = p.Contenido,
                                 FechaActualizacion = p.FechaActualizacion,
                                 UsuarioIdPropietario = p.UsuarioIdPropietario,
                                 UsuarioIdPropietarioNavigation = up
                             };

            var queryComentarios = from c in _context.Comentarios
                                   join up in _context.Usuarios on c.UsuarioIdPropietario equals up.UsuarioId
                                   select new Comentario
                                   {
                                       ComentarioId = c.ComentarioId,
                                       PostId = c.PostId,
                                       Contenido = c.Contenido,
                                       FechaActualizacion = c.FechaActualizacion,
                                       UsuarioIdPropietarioNavigation = up
                                   };

            List<Post> posts = queryPosts.ToList();
            List<Comentario> comentarios = queryComentarios.ToList();

            posts.ForEach(post =>
            {
                post.Comentarios = comentarios.Where(c => c.PostId == post.PostId).ToList();
            });

            return posts;
        }
        public Post GetPostById(int postId)
        {
            var queryPosts = from p in _context.Posts
                             join up in _context.Usuarios on p.UsuarioIdPropietario equals up.UsuarioId
                             where p.PostId == postId
                             select new Post
                             {
                                 PostId = p.PostId,
                                 Titulo = p.Titulo,
                                 Resumen = p.Resumen,
                                 Contenido = p.Contenido,
                                 FechaActualizacion = p.FechaActualizacion,
                                 UsuarioIdPropietario = p.UsuarioIdPropietario,
                                 UsuarioIdPropietarioNavigation = up
                             };

            var queryComentarios = from c in _context.Comentarios
                                   join up in _context.Usuarios on c.UsuarioIdPropietario equals up.UsuarioId
                                   where c.PostId == postId
                                   select new Comentario
                                   {
                                       ComentarioId = c.ComentarioId,
                                       PostId = c.PostId,
                                       Contenido = c.Contenido,
                                       FechaActualizacion = c.FechaActualizacion,
                                       UsuarioIdPropietarioNavigation = up
                                   };

            Post post = queryPosts.FirstOrDefault();
            post.Comentarios = queryComentarios.ToList();

            return post;
        }
    }
}
