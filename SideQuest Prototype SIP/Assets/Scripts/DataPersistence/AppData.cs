using System.Collections.Generic;

public class AppData
{
    /*TASK MANAGEMENT DATA*/
    public List<Task.TaskDetails> savedTasks;

    /* HUD DATA */
    public float enemyHealth;

    /* PRIZE SYSTEM DATA */
    public int currency;
    public List<string> collectedPrizes;

    /*Initial AppData Values*/
    public AppData()
    {
        this.currency = 0;
        this.savedTasks = new List<Task.TaskDetails>();
        this.collectedPrizes = new List<string>();
        this.enemyHealth = 36000;
    }
}
