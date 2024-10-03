using OnlineQuiz.BLL.Dtos.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.BLL.Managers.Track
{
    public interface ITrackManager
    {
        IEnumerable<TrackDto> GetAllTracks();
        TrackDto GetTrackById(int id);
        
        TrackDto AddTrack(TrackDto trackDto); 
     
        void UpdateTrack(TrackDto trackDto); 
        void DeleteTrack(int id); 
    }
}
