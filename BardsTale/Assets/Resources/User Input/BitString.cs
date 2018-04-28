//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class BitString {
//	private uint size {extern get;}
//	private bool[] array;
//	private bool errorFlag {extern get;}
//
//	public BitString(uint n){
//		array = new bool[n];
//		size=n;
//		errorFlag = false;
//	}
//
//	public BitString(int n){
//		array = new bool[n];
//		size=(uint)n;
//		errorFlag = false;
//	}
//
//	public BitString(string str) {
//		size = (uint)str.Length;
//		array = new bool[size];
//		errorFlag = false;
//
//		//fills the array with 0s and 1s, or -1 if the character is not one of the two
//		for(int i = 0; i< size; ++i) {
//			int test = (int)(str[i]-'0');
//			if(test == 0)
//				array[i] = false;
//			else if(test == 1)
//				array[i] = true;
//			else {
//				errorFlag = true;
//				break;
//			}
//		}
//	}
//
//	public int at(int i) {
//		if(i<size)
//			return array[i] ? 1 : 0;
//		return -1;
//	}
//
//	public void set(uint i, bool b) {
//		if(i<size)
//			array[i]=b;
//	}
//
//	public int[] toArray() {
//			int[] ret = new int[size];
//			for(int i = 0; i < size; ++i) {
//				ret[i] = this.at(i);
//			}
//
//			return ret;
//	}
//
//	public override int GetHashCode() {
//		return (int)size*590383+array.GetHashCode();
//	}
//
//	public override bool Equals(object obj) {
//		return this == (BitString)obj;
//	}
//
//	public static bool operator ==(BitString a, BitString b) {
//		if(a.size!=b.size)
//			return false;
//
//		for(int i = 0; i< a.size; ++i) {
//			if (a.at(i)!=b.at(i))
//				return false;
//		}
//
//		return true;
//	}
//
//	public static bool operator !=(BitString a, BitString b) {
//		return !(a==b);
//	}
//
//
//}
