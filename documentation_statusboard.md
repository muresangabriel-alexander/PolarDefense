# PolarDefense
Documentation - How to handle StatusBoard Information

A scriptable object is used to save the statusboard information (Vehicles destroyed/spawned, scraps collected, fish available/eaten, total amount of vehicles wave (optional)).
The script and scriptable object can be found in the StatusBoardSO folder in scripts.

For every information there is a getter,setter and a method to change/add value by a given integer number.

HOW TO USE: (see StatusBoard.cs for example)
- Create StatusBoardSO object (it has to be a SerializeField:
--  [SerializeField]
    private StatusBoardSO statusBoardObject;
- call statusBoardObject with method needed (e.g. GetDestroyedVehicles(), ChangeDestroyedVehiclesBy(number))
-- statusBoardObject.GetDestroyedVehicles()

