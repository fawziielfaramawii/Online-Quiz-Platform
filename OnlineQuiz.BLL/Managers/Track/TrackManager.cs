using AutoMapper;
using OnlineQuiz.BLL.Dtos.Track;
using OnlineQuiz.DAL.Data.Models;
using OnlineQuiz.DAL.Repositoryies.Base;
using OnlineQuiz.DAL.Repositoryies.TrackRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.BLL.Managers.Track
{
    public class TrackManager:ITrackManager
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IMapper _mapper;

        public TrackManager(ITrackRepository trackRepository, IMapper mapper)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
        }

        public IEnumerable<TrackDto> GetAllTracks()
        {
            var tracks = _trackRepository.GetAll();
            return _mapper.Map<IEnumerable<TrackDto>>(tracks);
        }

        public TrackDto GetTrackById(int id)
        {
            var track = _trackRepository.GetById(id);
            return _mapper.Map<TrackDto>(track);
        }

        public TrackDto AddTrack(TrackDto trackDto)
        {
            var track = _mapper.Map<Tracks>(trackDto);
            _trackRepository.Add(track);
            return _mapper.Map<TrackDto>(track); // Returning the added track as TrackDto
        }

        public void UpdateTrack(TrackDto trackDto)
        {
            var track = _mapper.Map<Tracks>(trackDto);
            _trackRepository.Update(track);
        }

        public void DeleteTrack(int id)
        {
            _trackRepository.DeleteById(id);
        }
    }
}
