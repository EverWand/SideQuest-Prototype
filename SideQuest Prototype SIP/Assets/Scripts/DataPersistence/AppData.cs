using System.Collections.Generic;

public class AppData
{
    
    /*TASK MANAGEMENT DATA*/
    public List<Task> taskList;

    /* HUD DATA */
    public float enemyHealth;

    /* PRIZE SYSTEM DATA */
    public int currency;
    public Prize[] collectedPrizes;

    public AppData()
    {
        // Default Constructor
    }
}
