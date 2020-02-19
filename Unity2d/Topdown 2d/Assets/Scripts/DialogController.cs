using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Topdown.Dialog {
    public class DialogController : MonoBehaviour {
        static private DialogController instance;

        static public void Show(int index) {
            instance.ShowDialog();
            instance.LoadDialog(index);
        }

        static public void Hide() {
            instance.HideDialog();
        }

        private DialogModel model;
        private DialogView view;


        void Awake() {
            instance = this;
            model = GetComponent<DialogModel>();
            view = GetComponent<DialogView>();
        }

        void Start() {
            view.Init(model);
            HideDialog();
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.F))
                HideDialog();
        }

        private void ShowDialog() {
            view.Show();
        }

        private void HideDialog() {
            view.Hide();
        }

        private void LoadDialog(int index) {
            //DialogModel.Dialog dialog = model.dialogs[index];
            //view.ShowText(model.textList[dialog.text]);
            view.ShowText(model.GetTextByDialogId(index));
            view.ShowFace(model.GetFaceByDialogId(index));
            view.ShowArrow(model.IsEndById(index));
        }

    }
}