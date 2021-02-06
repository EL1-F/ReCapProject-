using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccsess.Concrete.InMemory
{
    public class InMemoryColorDal:IColorDal
    {
        List<Color> _colors;

        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color { ColorId=1, ColorName="Metalik Gri"},
                new Color { ColorId=2, ColorName="Siyah"}
            };
        }

        public void Add(Color color)
        {
            _colors.Add(color);
        }


        public void Delete(Color Entity)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.ColorId == Entity.ColorId);
            _colors.Remove(colorToDelete);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        //public List<Color> GetById(int colorId)
        //{
        //    return _colors.Where(c => c.ColorId == colorId).ToList();
        //}

        public void Update(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(c => c.ColorId == color.ColorId);
            colorToUpdate.ColorName = color.ColorName;
        }
    }
}
