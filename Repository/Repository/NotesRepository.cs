using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class NotesRepository:INotesRepository
    {
        /// <summary>
        /// User Context Objects
        /// </summary>
        public readonly UserContext UserContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository"/> class
        /// </summary>
        /// <param name="userContext">UserContext userContext</param>
        public NotesRepository(UserContext userContext)
        {
            this.UserContext = userContext;
        }

        public string AddNotes(NotesModel notesModel)
        {
            try
            {
                if (notesModel != null)
                {
                    this.UserContext.Notes.Add(notesModel);
                    this.UserContext.SaveChanges();
                    return "Note Added Successfully !";
                }
                else
                {
                    return "Notes Not Added SuccessFully !";
                }
            
            }catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
