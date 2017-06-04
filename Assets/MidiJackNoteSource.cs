using UnityEngine;
using MidiJack;

public class MidiJackNoteSource : MonoBehaviour
{
    void NoteOn(MidiChannel channel, int note, float velocity)
    {
        Debug.Log("NoteOn: " + channel + "," + note + "," + velocity);
    }

    void NoteOff(MidiChannel channel, int note)
    {
        Debug.Log("NoteOff: " + channel + "," + note);
    }

    void Knob(MidiChannel channel, int knobNumber, float knobValue)
    {
        Debug.Log("Knob: " + knobNumber + "," + knobValue);
    }

    void OnEnable()
    {
        MidiMaster.noteOnDelegate += NoteOn;
        MidiMaster.noteOffDelegate += NoteOff;
    }

    void OnDisable()
    {
        MidiMaster.noteOnDelegate -= NoteOn;
        MidiMaster.noteOffDelegate -= NoteOff;
    }
}