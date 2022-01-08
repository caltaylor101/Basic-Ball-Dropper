using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newBehavior : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public GameObject gameRun;
    public GameObject gasBall;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameRun = GameObject.Find("GameRun");
        gasBall = GameObject.Find("TubePiston1");
        animator.SetBool("compressNow", false);
        GameObject[] currentGasParticles = GameObject.FindGameObjectsWithTag("GasParticle");
        foreach (GameObject gas in currentGasParticles)
        {
            Piston pistonScript = GameObject.Find("TubePiston1").GetComponent<Piston>();
            pistonScript.gasParticles -= 1;
            Destroy(gas);
        }
        if (gameRun.GetComponent<ImageFade>().gasCreatedBall >= GameObject.Find("TubePiston1").GetComponent<Piston>().gasCreatedBallProduction)
        {
            gameRun.GetComponent<ImageFade>().gasCreatedBall -= GameObject.Find("TubePiston1").GetComponent<Piston>().gasCreatedBallProduction;
            gasBall.GetComponent<Piston>().instantiateGasBall();
        }

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
