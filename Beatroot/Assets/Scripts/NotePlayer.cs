using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NotePlayer : MonoBehaviour
{
    public enum NoteId
    {
        A, C, E, F
    }
    [System.Serializable]
    public class Note
    {
        public NoteId note;
        public AudioSource audioSource;
    }
    public static NotePlayer instance;
    public List<NoteId> pattern;
    public List<Note> notes;
    public int currentNote = 0;
    private void Awake()
    {
        instance = this;
    }
    public void PlayNote()
    {
        notes.First(x => x.note == pattern[currentNote]).audioSource.Play();

        currentNote += 1;
        currentNote = currentNote % notes.Count;
    }

    public void MissNote()
    {

        currentNote += 1;
        currentNote = currentNote % notes.Count;
    }
}
