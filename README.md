<h1 class="display-4 text-center">Welcome to Toy Robot Simulator</h1>
<h3>Introduction:</h3>
Hey Everyone!!
<ul>
   <li>Meet Tammy. Tammy is Toy Robot.</li>
   <li>Tammy lives in a world which is a 5x5 Board.</li>
   <li>Tammy can be placed and moved on the board with the help of certain commands.</li>
   <li>User can play with Tammy with the help of this web application.</li>
   <li>User can enter a set of commands and get to know current position of tammy after the comamnds are executed.</li>
</ul>
<img  src="https://github.com/shivendrabhaskar/ToyRobotSimulator/blob/master/Robo.png" alt="Robo Guy" width="140" height="200"/>
<div>
   <p>
   <h3>Description and rules.</h3>
   <ul>
      <li>The application is a simulation of a toy robot moving on a square tabletop, of
         dimensions 5 units x 5 units.
      </li>
      <li>There are no other obstructions on the table surface.</li>
      <li>The robot is free to roam around the surface of the table, but must be prevented from
         falling to destruction. Any movement that would result in the robot falling from the
         table must be prevented, however further valid movement commands must still be
         allowed.
      </li>
      <li>The application should be able to read in any one of the following commands:<br />
         PLACE X,Y,F<br />
         MOVE<br />
         LEFT<br />
         RIGHT<br />
         REPORT
      </li>
      <li>PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH,
         EAST or WEST.
      </li>
      <li>The origin (0,0) can be considered to be the SOUTH WEST most corner.</li>
      <li>The first valid command to the robot is a PLACE command, after that, any sequence
         of commands may be issued, in any order, including another PLACE command. The
         application should discard all commands in the sequence until a valid PLACE
         command has been executed.
      </li>
      <li>MOVE will move the toy robot one unit forward in the direction it is currently facing.</li>
      <li>LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without
         changing the position of the robot.
      </li>
      <li>REPORT will announce the X,Y and F of the robot. This can be in any form, but
         standard output is sufficient.
      </li>
      <li>A robot that is not on the table should ignore the MOVE, LEFT, RIGHT and REPORT
         commands.
      </li>
   </ul>
   </p>
</div>
<h3>Constraints:</h3>
<ul>
   <li>The toy robot must not fall off the table during movement. This also includes the initial
      placement of the toy robot.
   </li>
   <li>Any move that would cause the robot to fall must be ignored.</li>
</ul>
<h3>Technical info:</h3>
<ul>
   <li>This is a Web application created using ASP.Net Core(6) MVC template from Visual Studio 2022.</li>
   <li>This application contains 2 pages Home and ToyOperator.</li>
   <li>Home Page contains the description and rules of the simulator.</li>
   <li>ToyOperator Page contains a Textbox (used for entering valid commands) and a Submit button (can be clisked after entering commands to get the current toy position).</li>
</ul>
<h3>Sample:</h3>
Please find below sample inputs and expected output from the application.
<ul>
   <li>Input 1:<br />
      PLACE 0,0,NORTH<br />
      MOVE<br />
      REPORT<br />
   </li>
   <li>Output 1:<br />
      0,1,NORTH
   </li>
   <br />
   <li>Input 2:<br />
      PLACE 1,2,EAST<br />
      MOVE<br />
      MOVE<br />
      LEFT<br />
      MOVE<br />
      REPORT<br />
   </li>
   <li>Output 2:<br />
      3,3,NORTH
   </li>
</ul>

This is a basic application created on a short notice and is open to modifications and enhancements, hence please excuse the naivety.
