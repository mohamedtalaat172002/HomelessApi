﻿using HomeCompassApi.Models;
using HomeCompassApi.Models.Facilities;

namespace HomeCompassApi.BLL.Facilities
{
    public class FacilityRepository : IRepository<Facility>
    {
        private readonly ApplicationDbContext _context;
        public FacilityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Facility entity)
        {
            _context.Facilities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Facilities.Remove(GetById(id));
            _context.SaveChanges();
        }

        public IEnumerable<Facility> GetAll() => _context.Facilities.ToList();
       
        public Facility GetById(int id) => _context.Facilities.FirstOrDefault(f => f.Id == id);


        public void Update(Facility entity)
        {
            _context.Facilities.Update(entity);
            _context.SaveChanges();
        }
    }
}
