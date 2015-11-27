using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DomainModel;
using DAL.Managers;
using DAL.Managers.IManager;

namespace DAL
{
    public class Facade
    {
        private IManager<Comment> _commentManager;
        private IManager<Event> _eventManager;
        private IManager<News> _newsManager;
        private IManager<Trainer> _trainerManager;

        public IManager<Comment> GetCommentManager()
        {
            if (_commentManager == null)
            {
                _commentManager = new CommentManager();
            }
            return _commentManager;
        }

        public IManager<Event> GetEventManager()
        {
            if (_eventManager == null)
            {
                _eventManager = new EventManager();
            }
            return _eventManager;
        }

        // if NewsManager is null, create a new NewsManager.
        public IManager<News> GetNewsManager()
        {
            if (_newsManager == null)
            {
                _newsManager = new NewsManager();
            }
            return _newsManager;
        }

        // if TrainerManager is null, create a new TrainerManager.
        public IManager<Trainer> GetTrainerManager()
        {
            return _trainerManager ?? (_trainerManager = new TrainerManager());
        }
    }
}
