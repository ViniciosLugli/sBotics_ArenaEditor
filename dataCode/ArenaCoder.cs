using Godot;
using System;

public class ArenaCoder : Node {

	public static string Reverse(string s){
		char[] arr = s.ToCharArray();
		Array.Reverse(arr);
		return new string(arr);
	}

	public string[] filter_code(string native_code){
		string[] final_code = (native_code.Replace("\n", "").Replace("\r", "").Replace("\b", "").Replace("\t", "")).Split(new char[] { ',' });
		GD.Print($"Codes array: {string.Join(", ", final_code)}");
		return final_code;
	}

	public void set_arena(string inter_code){
		string[] final_code = filter_code(inter_code);
		foreach (string code in final_code){
			byte pos_x = byte.Parse(Reverse(code.Substring(0, 2)));
			byte pos_y = byte.Parse(Reverse(code.Substring(2, 2)));
			short direction = short.Parse(code.Substring(6, 3));
			string compl = code.Substring(5, 1);
			GD.Print($"For code: '{code}' -> position: <{pos_x}, {pos_y}> | direction: {direction} | complement: {compl}");
		}
	}

	public override void _Ready(){
		set_arena("0000r0000,9000r0000,9090r0000,0090r0000");
	}
	public override void _Process(float delta){

	}
}
