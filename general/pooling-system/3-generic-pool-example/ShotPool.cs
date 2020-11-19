// This is the actual pool that gets used for blaster shots.
// Any number of pools can be created by simply extending
// `GenericObjectPool`.
//
// Attach this script to an empty gameObject in the scene. It
// needs to be instantiated and become part of the scene to work.
public class ShotPool : GenericObjectPool<BlasterShot> { }
