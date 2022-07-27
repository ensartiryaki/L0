using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
   public class UrunRepository
    {
        L0DbContext _ctx;
        public UrunRepository(L0DbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Urun> ListUrun()
        {
            return _ctx.Urunler.ToList();
        }
        public void AddOrUpdateUrun(Urun urun)
        {
            if (urun.Id<= 0)
            {
                _ctx.Urunler.Add(urun);
            }
            else
            {
                _ctx.Attach(urun);
                _ctx.Entry(urun).State = EntityState.Modified;

            }
            _ctx.SaveChanges();
        }
        public void Delete(int id)
        {
            var willBeDeleted = _ctx.Urunler.Find(id);
            _ctx.Urunler.Remove(willBeDeleted);
            _ctx.SaveChanges();

        }
        public List<Urun> AktifUrunler()
        {
            return  _ctx.Urunler.Where(c => c.Aktiflik == true).ToList();
            
        }
        public Urun GetUrunById(int id)
        {
            return _ctx.Urunler.FirstOrDefault(c=>c.Id==id);
        }
        public List<Urun> Search(string aranacakUrun,DateTime? skt)
        {
            var query = _ctx.Urunler.Where(c => 1 == 1);

            if (!String.IsNullOrEmpty(aranacakUrun))
            {
                query = query.Where(c => c.UrunAdi.Contains(aranacakUrun));
            }
            else if (skt.HasValue)
            {
                query = query.Where(c => c.SonKullanmaTarihi == skt);
            }
            return query.ToList();
        }
    }
}
