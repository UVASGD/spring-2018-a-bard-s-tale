using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* TODO:
 * 1. Implement the functions for outlook, assurance, and agency
 * 2. Add any other actions that allies should be able to do
 * 3. Figure out how we get d for each ally
 * 4. Figure out how to determine whether they are in battle or not
 */

//the abstract class for a generic ally
public abstract class Ally : MonoBehaviour
{
    //the modifier for the formulas to calculate the 3 qualities
    float d; 

    //Qualities to determine actions
    float outlook;
    float assurance;
    float agency;

    //determines whether or not the ally is in battle
    public bool isBattle;

    protected abstract void Start();

    protected abstract void Update();

    //sets the baseline fields for each ally. USE THIS IN Start() METHOD
    protected void setBaselineValues(float d, float initOutlook, float initAssurance, float initAgency)
    {
        this.d = d;
        outlook = initOutlook;
        assurance = initAssurance;
        agency = initAgency;
    }

    //uses the outlook, assurance, and agency fields to get the appropriate action
    void getAction()
    {
        //if the ally is battling
        if (isBattle)
        {
            if (outlook < 0)
            {
                if (assurance < 0)
                {
                    if (agency < 0) //if terrified, then retreat
                    {
                        retreat(); 
                    }
                    else //if nervous/curious, then do a safeAttack
                    {
                        safeAttack();
                    }
                }
                else
                {
                    if (agency < 0) //if defeated, then defend
                    {
                        defend();
                    }
                    else //if determined, then reckless attack
                    {
                        recklessAttack();
                    }
                }
            }
            else
            {
                if (assurance < 0)
                {
                    if (agency < 0) //if alert, then defend
                    {
                        defend();
                    }
                    else //if cautious, then safe attack
                    {
                        safeAttack();
                    }
                }
                else
                {
                    if (agency < 0) //if relenting, then have mercy
                    {
                        mercy();
                    }
                    else //if victorious, then strong attack
                    {
                        strongAttack();
                    }
                }
            }
        }
        else //if the ally is not battling, subject to change
        {
            if (outlook < 0)
            {
                if (assurance < 0)
                {
                    if (agency < 0) //if nervous, do nothing
                    {
                        noAction();
                    }
                    else //if forboding, then battle
                    {
                        battle();
                    }
                }
                else
                {
                    if (agency < 0) //if hopeless, then avoid battle
                    {
                        avoidBattle();
                    }
                    else //if determined/terrified, then move forward
                    {
                        moveForward();
                    }
                }
            }
            else
            {
                if (assurance < 0)
                {
                    if (agency < 0) //if hopeful, then nothing
                    {
                        noAction();
                    }
                    else //if excited, then move forward. If can, then battle
                    {
                        moveForward();
                        battle();
                    }
                }
                else
                {
                    if (agency < 0) //if content, then stay as is
                    {
                        stop();
                    }
                    else //if elated, then move forward. Shop if can.
                    {
                        moveForward();
                        shop();
                    }
                }
            }
        }
    }

    //modifies the outlook, assurance, and agency fields based on the qualities of the music played by the bard.
    //structure of musicQualities array: [tempo, frequency, volume, tension, tone]
    public void modifyAttributes(float[] musicQualities)
    {
        modifyOutlook(musicQualities);
        modifyAssurance(musicQualities);
        modifyAgency(musicQualities);
    }

    //modifies the outlook field based on the music qualities
    float modifyOutlook(float[] musicQualities)
    {
        return 0.0f;
    }

    //modifies the assurance field based on the music qualities
    float modifyAssurance(float[] musicQualities)
    {
        return 0.0f;
    }

    //modifies the agency field based on the music qualities
    float modifyAgency(float[] musicQualities)
    {
        return 0.0f;
    }

    //actions that each ally could take. MUST ALL BE IMPLEMENTED IN SUBCLASSES

    //battle actions
    protected abstract void retreat();
    protected abstract void mercy();
    protected abstract void safeAttack();
    protected abstract void recklessAttack();
    protected abstract void strongAttack();
    protected abstract void defend();

    //non-battle (regular) actions. These can be changed later
    protected abstract void noAction();
    protected abstract void stop();
    protected abstract void moveForward();
    protected abstract void battle();
    protected abstract void avoidBattle();
    protected abstract void shop();

}
