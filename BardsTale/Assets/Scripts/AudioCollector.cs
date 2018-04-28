using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollector : MonoBehaviour 
    {
        //holds all the chords
        public AudioSource I;
        public AudioSource i;
        public AudioSource IIb;
        public AudioSource iib;
        public AudioSource II;
        public AudioSource ii;
        public AudioSource IIIb;
        public AudioSource iiib;
        public AudioSource III;
        public AudioSource iii;
        public AudioSource IV;
        public AudioSource iv;
        public AudioSource Vb;
        public AudioSource vb;
        public AudioSource V;
        public AudioSource v;
        public AudioSource VIb;
        public AudioSource vib;
        public AudioSource VI;
        public AudioSource vi;
        public AudioSource VIIb;
        public AudioSource viib;
        public AudioSource VII;
        public AudioSource vii;

        public AudioSource[] clips;

        void Start()
        {
            clips = new AudioSource[] { I, i, IIb, iib, II, ii, IIIb, iiib, III, iii, IV, iv, Vb, vb, V, v, VIb, vib, VI, vi, VIIb, viib, VII, vii };
        }
 
}
