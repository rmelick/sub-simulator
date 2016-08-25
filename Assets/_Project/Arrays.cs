using UnityEngine;
using System.Collections;

public class Arrays {
	public static int next(Object[] array, int currentIndex) {
		return adjustIndex(array, currentIndex, 1);
	}

	public static int previous(Object[] array, int currentIndex) {
		return adjustIndex(array, currentIndex, -1);
	}

	public static int adjustIndex(Object[] array, int currentIndex, int adjustBy) {
		return ((currentIndex + adjustBy) % array.Length + array.Length) % array.Length;
	}
}
