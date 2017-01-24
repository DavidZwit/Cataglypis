﻿using UnityEngine;
using System.Collections;

public struct DialogueStruct
{
    public DialogueStruct(string _name, string _line, string _art, bool _allignmentRight)
    {
        name = _name;
        line = _line;
        art = _art;
        allignmentRight = _allignmentRight;
    }
    public string name;
    public string line;
    public string art;
    public bool allignmentRight;
}

public class DialogueData {
    public static string Wizcat = "Wizcat";
    public static string Ball = "Ball";
    public static string Mysterious = "Mysterious Narrator";
    public static string UI = "Notification";

    public static DialogueStruct[] dialogueLines1 = new DialogueStruct[]
    {
        new DialogueStruct(Wizcat, "Hello human. Or should I say ball…","Wizcat", false),
        new DialogueStruct(Wizcat, "You are stuck in the WizCat Nightmare","Wizcat",false),
        new DialogueStruct(Wizcat, "You’ll need to prove yourself worthy if you want to become the ultimate play ball...","Wizcat",false),
        new DialogueStruct(Wizcat, "EHM I MEAN if you want to get out!","Wizcat",false),
        new DialogueStruct(UI, "Tap and hold to move around.","none",false),
    };

    public static DialogueStruct[] dialogueLines2 = new DialogueStruct[]
    {
        new DialogueStruct(Mysterious, "You will need this if you want to stand any chance to end this nightmare.","mysterious",true),
        new DialogueStruct(UI, "You obtained the mass scanner!","none",false),
        new DialogueStruct(UI, "You can now see weight values.","none",false),
        new DialogueStruct(UI, "Swipe to dash in a direction and interact with other balls.","none",false),
    };

    public static DialogueStruct[] dialogueLines3 = new DialogueStruct[]
    {
        new DialogueStruct(Mysterious, "I had to let you learn by yourself, didn’t I?","mysterious",true),
        new DialogueStruct(Mysterious, "Now don’t make a waste of that scanner I gave you.","mysterious",true),
    };

    public static DialogueStruct[] dialogueLines4 = new DialogueStruct[]
    {
        new DialogueStruct(Wizcat, "Bwhahaha!","laughingcat", false),
        new DialogueStruct(Wizcat, "You think you can stand a chance against the majestic Tovertree?!","Wizcat", false),
        new DialogueStruct(Wizcat, "Well I hope you like limbos…","Wizcat", false),
        new DialogueStruct(Wizcat, "You think you can stand a chance against the majestic Tovertree?!","laughingcat", false),
    };

    public static DialogueStruct[] dialogueLines5 = new DialogueStruct[]
    {
        new DialogueStruct(Wizcat, "How is it possible?!","Wizcat", false),
        new DialogueStruct(Wizcat, "Your luck is not going to last forever...","Wizcat", false),
        new DialogueStruct(Wizcat, "In fact, abandon hope if you enter here.","Wizcat", false),
    };


}
