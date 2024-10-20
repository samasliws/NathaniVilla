using NathaniVilla.Application.Common.Interfaces;
using NathaniVilla.Application.Services.Interface;
using NathaniVilla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NathaniVilla.Application.Services.Implementation
{
    public class AmenityService : IAmenityService
    {
        #region Amenity Repo Constructors
        private readonly IUnitOfWork _unitOfWork;
        public AmenityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        public void CreateAmenity(Amenity amenity)
        {
            _unitOfWork.Amenity.Add(amenity);
            _unitOfWork.Save();
        }

        public bool DeleteAmenity(int id)
        {
            try
            {
                var amenity = _unitOfWork.Amenity.Get(u => u.Id == id);
                if (amenity != null)
                {
                    _unitOfWork.Amenity.Delete(amenity);
                    _unitOfWork.Save();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException($"Amenity with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public IEnumerable<Amenity> GetAllAmenities()
        {
            return _unitOfWork.Amenity.GetAll(includeProperties: "Villa");
        }

        public Amenity GetAmenityById(int id)
        {
            return _unitOfWork.Amenity.Get(u => u.Id == id, includeProperties: "Villa");
        }

        public void UpdateAmenity(Amenity amenity)
        {          
            ArgumentNullException.ThrowIfNull(amenity);
            _unitOfWork.Amenity.Update(amenity);
            _unitOfWork.Save();
        }
    }
}
