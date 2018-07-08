using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class y_text_load : MonoBehaviour {
	string file_name;
	public Image black_out;
	public GameObject sky;
	public Image[] Image_=new Image[5];
	public Image back_Img;
	public AudioSource se;
	public AudioSource se_mono;
	public AudioSource se_voice;
	char[] csvDatas=new char[10000];  // CSVの中身を入れる
	int height;
	bool trigger;
	bool logflg;
	bool ani_flg;
	bool scean_change;
	float time;
	float alpha;
	float alpha_sky;
	public Text _text;
	public int stage_num;
	public bool debagflg;

	// Use this for initialization
	void Start () {
		if(debagflg)Player.stagecount = stage_num;
		file_name = "stage_" + Player.stagecount.ToString();

		if(Player.stagecount != 5)Image_ [Player.stagecount].enabled = true;
		Player.stagecount++;
		Debug.Log (Player.stagecount);
		Load_Text (file_name);
		time = 0;
		alpha = 0;
		alpha_sky = 1;
		ani_flg = false;
		scean_change = false;
		trigger = true;
		logflg = false;
		se.Play ();
	}

	// Update is called once per frame
	void Update () {
		if (ani_flg) {
			alpha_sky -= 0.1f;
			sky.GetComponent<SpriteRenderer> ().color = new Color (1f,1f,1f,alpha_sky);
			time += Time.deltaTime;	
			if (time > 2f)ani_flg = false;
			return;
		}

		//シーン切り替え
		if (scean_change) {
			alpha += 0.05f;
			black_out.GetComponent<Image> ().color = new Color (0f, 0f, 0f, alpha);
			if (alpha > 1.0f){
				if (Player.stagecount == 6) {
					SceneManager.LoadScene ("title");
				}
				else {
					if (Player.stagecount == 1) {
						SceneManager.LoadScene ("y_tutorial");
					}
					else if (Player.stagecount == 6) {
						SceneManager.LoadScene ("title");
					}
					else {
						file_name = "stage_" + Player.stagecount.ToString ();
						SceneManager.LoadScene (file_name);
					}
				}
			}
		}

		if (trigger) {
			//シーンをロード
			if (csvDatas [height] == '+') {
				scean_change = true;
				back_Img.enabled = false;
				return;
			}
			if (csvDatas [height] == '@') {
				height++;
				se_voice.Play ();
			}
			//'/'がきたら表示終了
			if (csvDatas [height] == '/'||csvDatas [height] == '*') {
				height++;
				se.Stop ();
				trigger = false;
				if (csvDatas [height - 1] == '*') {
					ani_flg = true;
				}
			}
			if (csvDatas [height] == '$') {
				height++;
				se_mono.Play ();
			}
			Write_Text ();
			height++;
		}
	}

	//CSV読み込み
	void Load_Text(string file_name){
		height = 0;
		TextAsset csv = Resources.Load("CSV/" + file_name) as TextAsset;
		StringReader reader = new StringReader(csv.text);
		while (reader.Peek() > -1) {
			reader.ReadBlock (csvDatas,0,csvDatas.Length);
		}
	}

	//テキストを書く
	void Write_Text(){
		if(csvDatas [height]=='#')_text.GetComponent<Text> ().text += '\n';
		else if(csvDatas [height] != '\n')_text.GetComponent<Text> ().text += csvDatas [height];
	}

	//タップしたら今あるテキストをクリアーしてトリガーをtrueにする
	public void push(){
		if (scean_change)
			return;
		//Textに記載中にタップすると全部表示する
//		if (!logflg&&trigger) {
//			while(csvDatas [height] != '/'){
//				Write_Text ();
//				height++;
//				trigger = false;
//			}
//			return;
//		}
		if (!ani_flg) {
			if (!trigger) {
				trigger = true;
				_text.GetComponent<Text> ().text = "";
				if (csvDatas [height+1] != '+'&&csvDatas [height+1] != '$')
					se.Play ();
			}

		}
	}
}
