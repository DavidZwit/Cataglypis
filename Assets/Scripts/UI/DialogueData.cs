using UnityEngine;
using System.Collections;

public struct DialogueStruct
{
    public DialogueStruct(string _name, string _line, string _art)
    {
        name = _name;
        line = _line;
        art = _art;
    }
    public string name;
    public string line;
    public string art;
}

public class DialogueData {
    public static string Wizcat = "Wizcat";
    public static string Ball = "Ball";

    public static DialogueStruct[] dialogueLines1 = new DialogueStruct[]
    {
        new DialogueStruct(Wizcat, "hello ball!","Wizcat"),
        new DialogueStruct(Ball, ".    .   .   .   .   .   .   .", "ball"),
        new DialogueStruct(Wizcat, "I am the wizkat cat! And you are stuck in the nightmare! The onlyway to get out is to solve my puzzles! If you fail, you'll be stuck in libmo!","Wizcat"),
        new DialogueStruct(Wizcat, "HAHAHAHAHA!!!","laughingcat"),
        new DialogueStruct(Wizcat, "I do wish you good luck though!","Wizcat"),
        new DialogueStruct(Wizcat, "Lets begin!","Wizcat"),
    };
    public static DialogueStruct[] dialogueLines2 = new DialogueStruct[]
    {
        new DialogueStruct(Wizcat, "HAHAHAHAHA!!!","laughingcat"),
        new DialogueStruct(Wizcat, "You'll never get out!","Wizcat"),
    };

    public static DialogueStruct[] dialogueLines3 = new DialogueStruct[]
    {
        new DialogueStruct(Wizcat, "This time you get away with it, but don't keep your luck high! HAHAHA!","Wizcat"),
    };

}
