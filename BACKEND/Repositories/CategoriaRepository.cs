using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Interfaces;
using BACKEND.Domains;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories {
    public class CategoriaRepository : ICategoria {
        public async Task<Categoria> Alterar (Categoria categoria) {
            using (GufosContext _Contexto = new GufosContext ()) {
                // Comparamos os atributos que foram modificados através do EF
                _Contexto.Entry (categoria).State = EntityState.Modified;
                await _Contexto.SaveChangesAsync ();
                return categoria;

            }
        }

        public async Task<Categoria> BuscarPorID (int id) {
            using (GufosContext _Contexto = new GufosContext ()) {
                return await _Contexto.Categoria.FindAsync (id);
            }

        }

        public async Task<Categoria> Excluir (Categoria categoria) {
            using (GufosContext _Contexto = new GufosContext ()) {
                _Contexto.Categoria.Remove (categoria);
                await _Contexto.SaveChangesAsync ();
                return categoria;
            }
        }

        public async Task<List<Categoria>> Listar () {
            using (GufosContext _Contexto = new GufosContext ()) {
                return await _Contexto.Categoria.ToListAsync ();
            }
        }

        public async Task<Categoria> Salvar (Categoria categoria) {
            using (GufosContext _contexto = new GufosContext ()) {
                // Tratamos contra ataques de SQL Injection
                await _contexto.AddAsync (categoria);
                // Salvamos efetivamente o nosso objeto no banco de dados
                await _contexto.SaveChangesAsync ();

                return categoria;

            }

        }
    }
}
