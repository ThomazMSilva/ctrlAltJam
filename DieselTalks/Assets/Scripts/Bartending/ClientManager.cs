using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bartending
{
    public class ClientManager : MonoBehaviour
    {
        public Client[] clients;
        public Client currentClient {  get; private set; }

        public void UpdateCurrentClient(int clientIndex)
        {
            if (clientIndex >= clients.Length) { return; }
            if (currentClient != null)
            {
                //Debug.Log($"Desativando cliente {currentClient.name}");
                currentClient.gameObject.SetActive(false);
            }
            currentClient = clients[clientIndex];
            //Debug.Log($"Ativando cliente {currentClient.name}");
            currentClient.gameObject.SetActive(true);
        }
        public void UpdateClientToLevel() => UpdateCurrentClient(GameManager.Instance.LevelManager.level);

        private void Start()
        {
            UpdateClientToLevel();

            GameManager.Instance.LevelManager.OnLevelUp += UpdateClientToLevel;
        }

        private void OnDestroy()
        {
            GameManager.Instance.LevelManager.OnLevelUp -= UpdateClientToLevel;
        }

        public void ChangeClientEnjoymentLevel()
        {
            currentClient.ChangeEnjoymentLevel(DrinkManager.GetTexture, DrinkManager.GetTaste);
        }
    }
}